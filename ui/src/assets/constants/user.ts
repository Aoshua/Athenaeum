import IToken from "./token"

export default interface IUser {
    id: number
    firstName: string
    lastName: string
    username: string
    email: string
    token: IToken | undefined
}