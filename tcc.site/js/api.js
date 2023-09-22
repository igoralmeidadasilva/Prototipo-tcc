export async function getAllNamedEntities() {
    const url = "http://localhost:5086/api";
    try {
        const fetchResponse = await fetch(url);
        const jsonData = await fetchResponse.json();
        return jsonData;
    } catch (error) {
        console.error("Ocorreu um erro ao fazer a solicitação:", error);
    }
}

export async function postNamedEntity(entidade, codigo) {
    const url = "http://localhost:5086/api";
    const data = { nome: entidade, codEntidade: codigo}
    fetch(url, {
    method: "POST",
    headers: {
        "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
    })
    .then((response) => response.json())
    .then((data) => {
        console.log("Success:", data);
    })
    .catch((error) => {
        console.error("Error:", error);
    });
}

export async function getExempleBula() {
    const url = "http://localhost:5086/api/bula";
    try {
        const fetchResponse = await fetch(url);
        const jsonData = await fetchResponse.json();
        return jsonData;
    } catch (error) {
        console.error("Ocorreu um erro ao fazer a solicitação:", error);
    }
}

export async function getResetDB() {
    const url = "http://localhost:5086/api/reset";
    try {
        const fetchResponse = await fetch(url);
        const jsonData = await fetchResponse.json();
        return jsonData;
    } catch (error) {
        console.error("Ocorreu um erro ao fazer a solicitação:", error);
    }
}

