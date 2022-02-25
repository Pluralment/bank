import { Currency } from "./currency";
import { DepositType } from "./depositType";
import { User } from "./user";

export interface DepositContract {
    id: number;
    number: string;
    startDate: Date;
    endDate: Date;
    currency: Currency;
    isClosed: boolean;
    amount: number;
    depositType: DepositType;
    client: User;
}