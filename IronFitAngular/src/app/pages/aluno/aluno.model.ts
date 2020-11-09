export class Aluno {
    id: number;
    nome: string;
    cpf: string;
    dataNascimentoPicker: any;
    dataNascimento: Date;
    dataMatriculaPicker: any;
    dataMatricula: Date;
    idModalidade: number;
    ddd: string;
    numeroTelefone: string;
    cidade: string;
    rua: string;
    numero: number;

    constructor() {
        this.idModalidade = 0;
        this.id = 0;
    }
}