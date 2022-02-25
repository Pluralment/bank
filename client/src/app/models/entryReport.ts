export interface EntryReport {
    id: number;
    dateTime: Date;
    fromAccountName: string;
    toAccountName: string;
    fromDebt: number;
    fromCredit: number;
    toDebt: number;
    toCredit: number;
};