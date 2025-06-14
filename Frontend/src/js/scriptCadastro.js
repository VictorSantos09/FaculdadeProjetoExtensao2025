document.addEventListener("DOMContentLoaded", () => {
  const form = document.getElementById("form");

  form.addEventListener("submit", async (event) => {
      event.preventDefault();

      // Campos
      const nome = document.getElementById("event_name");
      const descricao = document.getElementById("description");
      const observacao = document.getElementById("observation");
      const dataInicio = document.getElementById("start_date");
      const dataFim = document.getElementById("end_date");

      // Limpa mensagens anteriores
      clearValidation();

      const errors = [];

      // Validação: Nome
      if (!nome.value.trim()) {
          setError(nome, "O nome é obrigatório.");
          errors.push("nome");
      } else if (nome.value.trim().length < 3 || nome.value.trim().length > 75) {
          setError(nome, "O nome deve ter entre 3 e 75 caracteres.");
          errors.push("nome");
      }

      // Validação: Data de Início
      if (!dataInicio.value) {
          setError(dataInicio, "A data de início é obrigatória.");
          errors.push("dataInicio");
      } else {
          const hoje = new Date();
          const inicio = new Date(dataInicio.value);
          if (inicio < hoje) {
              setError(dataInicio, "A data de início deve ser hoje ou futura.");
              errors.push("dataInicio");
          }
      }

      // Validação: Data de Fim
      if (!dataFim.value) {
          setError(dataFim, "A data de fim é obrigatória.");
          errors.push("dataFim");
      } else if (dataInicio.value) {
          const fim = new Date(dataFim.value);
          const inicio = new Date(dataInicio.value);
          if (fim <= inicio) {
              setError(dataFim, "A data de fim deve ser posterior à de início.");
              errors.push("dataFim");
          }
      }

      if (errors.length > 0) return;

      const data = {
          nome: nome.value.trim(),
          descricao: descricao.value.trim(),
          observacao: observacao.value.trim(),
          dataInicio: dataInicio.value,
          dataFim: dataFim.value
      };

      try {
          const response = await fetch("https://localhost:7282/eventos", {
              method: "POST",
              headers: {
                  "Content-Type": "application/json"
              },
              body: JSON.stringify(data)
          });

          if (!response.ok) throw new Error(`Erro: ${response.status}`);

          const result = await response.json();
          alert("Evento criado com sucesso!");
          form.reset();
      } catch (error) {
          console.error("Erro ao enviar dados:", error);
          alert("Ocorreu um erro ao criar o evento.");
      }
  });

  function setError(element, message) {
      element.classList.add("invalid");
      const errorDiv = document.getElementById(`error-${element.id}`);
      if (errorDiv) errorDiv.textContent = message;
  }

  function clearValidation() {
      const errorMessages = document.querySelectorAll(".error-message");
      errorMessages.forEach(el => el.textContent = "");

      const invalidFields = document.querySelectorAll(".invalid");
      invalidFields.forEach(el => el.classList.remove("invalid"));
  }
});
