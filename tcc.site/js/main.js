import { getAllNamedEntities, getExempleBula, postNamedEntity, getResetDB } from './api.js';

var contador_label = -1
const entidades = await getExempleBula()

window.onload = atualizar_label(), carregar_entidades_nomeadas()
    
async function atualizar_label(){
    contador_label += 1
    const label = document.getElementById('label_entidade')
    if (contador_label >= entidades.length){
        label.textContent = "Nenhuma Entidade"
    } else {
        label.textContent = entidades[contador_label]
    }
}

async function carregar_entidades_nomeadas(){
    const container = document.querySelector('.container-entidadesNomeadas')
    const entidades = await getAllNamedEntities()
    await Promise.all(entidades.map(async element => {
        const description = document.createElement('p');
        description.textContent = element.nome + " : " + classifica_entidade(element.codEntidade); 
        container.appendChild(description);
    }));
}

function atualizar_entidades_nomeadas(nome, codigo){
    const container = document.querySelector('.container-entidadesNomeadas')
    const description = document.createElement('p');
    description.textContent = nome + " : " + codigo; 
    container.appendChild(description);
}

function classifica_entidade(codigo){
    var entidade;
    switch(codigo){
        case 1:
            entidade = "Doença"
            break
        case 2:
            entidade = "Sintoma"
            break
        case 3:
            entidade = "Medicamento"
            break
        case 4:
            entidade = "Pessoa"
            break
        case 5:
            entidade = "Princípio Ativo"
            break
        case 6:
            entidade = "Outros"
            break
        default:
            entidade = "Entidade"
            break;
    }
    return entidade
}

const btn_doenca = document.getElementById("btn-doenca");
btn_doenca.addEventListener("click", async ()=> {
    var nome = entidades[contador_label]
    var codigo = 1
    postNamedEntity(nome, codigo)
    atualizar_label()
    atualizar_entidades_nomeadas(nome, classifica_entidade(codigo))
})

const btn_sintoma = document.getElementById("btn-sintoma");
btn_sintoma.addEventListener("click", async ()=> {
    var nome = entidades[contador_label]
    var codigo = 2
    postNamedEntity(nome, codigo)
    atualizar_label()
    atualizar_entidades_nomeadas(nome, classifica_entidade(codigo))
})

const btn_medicamento = document.getElementById("btn-medicamento");
btn_medicamento.addEventListener("click", async ()=> {
    var nome = entidades[contador_label]
    var codigo = 3
    postNamedEntity(nome, codigo)
    atualizar_label()
    atualizar_entidades_nomeadas(nome, classifica_entidade(codigo))
})

const btn_pessoa = document.getElementById("btn-pessoa");
btn_pessoa.addEventListener("click", async ()=> {
    var nome = entidades[contador_label]
    var codigo = 4
    postNamedEntity(nome, codigo)
    atualizar_label()
    atualizar_entidades_nomeadas(nome, classifica_entidade(codigo))
})

const btn_principio = document.getElementById("btn-principio");
btn_principio.addEventListener("click", async ()=> {
    var nome = entidades[contador_label]
    var codigo = 5
    postNamedEntity(nome, codigo)
    atualizar_label()
    atualizar_entidades_nomeadas(nome, classifica_entidade(codigo))
})

const btn_outro = document.getElementById("btn-outro");
btn_outro.addEventListener("click", async ()=> {
    var nome = entidades[contador_label]
    var codigo = 6
    postNamedEntity(nome, codigo)
    atualizar_label()
    atualizar_entidades_nomeadas(nome, classifica_entidade(codigo))
})

const btn_reset = document.getElementById("btn-reset");
btn_reset.addEventListener("click", async ()=> {
    await getResetDB()
})



    
