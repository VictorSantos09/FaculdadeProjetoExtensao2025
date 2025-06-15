document.addEventListener("DOMContentLoaded", async function () {
  const tbody = document.querySelector("tbody");

  try {
    const response = await fetch("https://localhost:7282/eventos");
    const eventos = await response.json();

    eventos.forEach((evento) => {
      const tr = document.createElement("tr");

      tr.innerHTML = `
        <td>${evento.nome}</td>
        <td>${evento.descricao}</td>
        <td>${formatarDataHora(evento.datA_INICIO)}</td>
        <td>${formatarDataHora(evento.datA_FIM)}</td>
        <td class="acao"><button onclick="editarEvento('${
          evento.id
        }')"><i class='bx bxs-edit'></i></button></td>
        
        <td class="acao"><button onclick="excluirEvento('${
          evento.id
        }')"><i class='bx bxs-trash'></i></button></td>

        <td class="acao"><button onclick="exibirQRCode('${
          evento.id
        }')"><i class='bx bx-qr'></i></button></td>
      `;

      tbody.appendChild(tr);
    });
  } catch (error) {
    console.error("Erro ao buscar eventos.", error);
    tbody.innerHTML = `<tr><td colspan="7">Erro ao carregar eventos.</td></tr>`;
  }
});

// Redireciona para a tela de cadastro para alteração
function editarEvento(id) {
  window.location.href = `cadastro.html?id=${id}`;
}

function exibirQRCode(id) {
  const modal = document.getElementById("modalQRCode");
  const qrcodeContainer = document.getElementById("qrcode");

  // Limpa QR Code anterior
  qrcodeContainer.innerHTML = "";

  // Gere o QR code (aqui você pode personalizar o texto ou URL)
  // Por exemplo, um link para o evento
  const urlEvento = "http://127.0.0.1:5500/confirmarPresenca.html?evento=" + id;

  new QRCode(qrcodeContainer, {
    text: urlEvento,
    width: 200,
    height: 200,
    colorDark: "#000000",
    colorLight: "#ffffff",
    correctLevel: QRCode.CorrectLevel.H,
  });

  // Mostra modal
  modal.style.display = "flex";
}

// Fecha o modal ao clicar no botão
document.getElementById("btnFecharModal").addEventListener("click", () => {
  document.getElementById("modalQRCode").style.display = "none";
});

// Fecha o modal se clicar fora da caixa de conteúdo
window.addEventListener("click", (event) => {
  const modal = document.getElementById("modalQRCode");
  if (event.target === modal) {
    modal.style.display = "none";
  }
});

function formatarDataHora(dataISO) {
  if (!dataISO) return "";
  const data = new Date(dataISO);
  const dia = String(data.getDate()).padStart(2, "0");

  const mes = String(data.getMonth() + 1).padStart(2, "0");

  const ano = data.getFullYear();

  const hora = String(data.getHours()).padStart(2, "0");

  const minuto = String(data.getMinutes()).padStart(2, "0");

  return `${dia}/${mes}/${ano} ${hora}:${minuto}`;
}

async function excluirEvento(id) {
  if (!confirm("Deseja realmente excluir este evento?")) {
    return; // usuário cancelou
  }

  try {
    const response = await fetch(`https://localhost:7282/eventos?id=${id}`, {
      method: "DELETE",
    });

    if (response.ok) {
      const botaoExcluir = document.querySelector(
        `button[onclick="excluirEvento('${id}')"]`
      );
      if (botaoExcluir) {
        const linha = botaoExcluir.closest("tr");

        linha.remove();
      }
      alert("Evento excluído com sucesso!");
    } else {
      alert("Erro ao excluir o evento. Tente novamente.");
    }
  } catch (error) {
    console.error("Erro ao excluir evento.", error);
    alert("Erro de conexão.");
  }
}
