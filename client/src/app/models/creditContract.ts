import { CreditType } from "./creditType";
import { Currency } from "./currency";
import { User } from "./user";

export interface CreditContract {
    id: number;
    number: string;
    startDate: Date;
    endDate: Date;
    currency: Currency;
    isClosed: boolean;
    amount: number;
    creditType: CreditType;
    client: User;
};