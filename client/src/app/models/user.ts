import { City } from "./city";
import { Country } from "./country";
import { FamilyPosition } from "./familyPosition";
import { Invalidity } from "./invalidity";

export interface User {
    id: number,
    surname: string,
    name: string,
    fatherName: string,
    dateOfBirth: Date,
    gender: string,
    passportSerial: string,
    passportNumber: string,
    issuedBy: string,
    issuedDate: Date,
    identifyNumber: string,
    cityOfResidence: City,
    addressOfResidence: string,
    homePhone: string,
    cellPhone: string,
    email: string,
    placeOfWork: string,
    position: string,
    livingCity: City,
    livingAddress: string,
    familyPosition: FamilyPosition,
    citizen: Country,
    invalidity: Invalidity,
    retired: boolean,
    monthlyIncome: number,
    military: boolean
}