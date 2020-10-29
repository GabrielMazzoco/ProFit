export class Pagamento {
    valor: number;
    idAluno: number;
    mesReferencia: number;
    anoReferencia: number;
    mesInteiro: boolean;
    quantidadeDias: number;

    constructor() {
        this.mesReferencia = 0;
        this.mesInteiro = true;
    }
}