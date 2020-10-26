export class Aluno {
    id: number;
    nome: string;
    cpf: string;
    dataNascimentoPicker: any;
    dataNascimento: Date;
    dataMatriculaPicker: any;
    dataMatricula: Date;
    idModalidade: number;

    constructor() {
        this.idModalidade = 0;
        this.id = 0;
    }
}