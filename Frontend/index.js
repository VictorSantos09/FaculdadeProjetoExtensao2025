document.addEventListener("DOMContentLoaded", function () {
    const form = document.getElementById("form");

    form.addEventListener("submit", async function (event) {
        event.preventDefault();

        const data = {
            nome: document.getElementById("event_name").value.trim(),
            descricao: document.getElementById("description").value.trim(),
            observacao: document.getElementById("observation").value.trim(),
            dataInicio: document.getElementById("start_date").value,
            dataFim: document.getElementById("end_date").value
        };

        try {
            const response = await fetch("https://localhost:7282/eventos", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(data)
            });

            if (!response.ok) {
                throw new Error(`Erro: ${response.status}`);
            }

            const result = await response.json();
            alert("Evento criado com sucesso!");
            console.log(result);

            form.reset();
        } catch (error) {
            console.error("Erro ao enviar dados:", error);
            alert("Ocorreu um erro ao criar o evento.");
        }
    });
});
