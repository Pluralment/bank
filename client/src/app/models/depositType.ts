export interface DepositType {
    id: number;
    name: string;
    interest: number;
    isFixedInterest: boolean;
    minContribution: number;
    maxContribution: number;
    isRevocable: boolean;
}