document.addEventListener("DOMContentLoaded", async function () {
  const tbody = document.querySelector("tbody");

  try {
    const response = await fetch("https://localhost:7282/eventos"); // Substitua pela URL real da sua API
    const eventos = await response.json();

    eventos.forEach((evento) => {
      const tr = document.createElement("tr");

      tr.innerHTML = `
        <td>${evento.nome}</td>
        <td>${evento.descricao}</td>
        <td>${formatarDataHora(evento.datA_INICIO)}</td>
        <td>${formatarDataHora(evento.datA_FIM)}</td>
        <td class="acao"><button onclick="editarEvento(${evento.id})"><i class='bx bxs-edit'></i></button></td>
        <td class="acao"><button onclick="excluirEvento(${evento.id})"><i class='bx bxs-trash'></i></button></td>
      `;

      tbody.appendChild(tr);
    });
  } catch (error) {
    console.error("Erro ao buscar eventos:", error);
    tbody.innerHTML = `<tr><td colspan="6">Erro ao carregar eventos.</td></tr>`;
  }
});

function editarEvento(id) {
  window.location.href = `cadastro.html?id=${id}`;
}

// Função para formatar data ISO (yyyy-mm-dd ou yyyy-mm-ddTHH:mm:ss) para dd/mm/yyyy
function formatarDataHora(dataISO) {
  if (!dataISO) return "";
  const data = new Date(dataISO);
  const dia = String(data.getDate()).padStart(2, '0');
  const mes = String(data.getMonth() + 1).padStart(2, '0');
  const ano = data.getFullYear();
  const hora = String(data.getHours()).padStart(2, '0');
  const minuto = String(data.getMinutes()).padStart(2, '0');
  return `${dia}/${mes}/${ano} ${hora}:${minuto}`;
}

async function excluirEvento(id) {
  if (!confirm("Deseja realmente excluir este evento?")) {
    return; // Usuário cancelou
  }

  try {
    const response = await fetch(`https://localhost:7282/eventos?id=${id}`, {
      method: "DELETE",
    });

    if (response.ok) {
      // Encontre o botão clicado e remova a linha da tabela
      const botaoExcluir = document.querySelector(`button[onclick="excluirEvento(${id})"]`);
      if (botaoExcluir) {
        const linha = botaoExcluir.closest("tr");
        linha.remove();
      }
      alert("Evento excluído com sucesso!");
    } else {
      alert("Erro ao excluir o evento. Tente novamente mais tarde.");
    }
  } catch (error) {
    console.error("Erro ao excluir evento:", error);
    alert("Erro de conexão. Verifique se a API está disponível.");
  }
}
