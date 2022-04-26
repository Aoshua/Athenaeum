import { reactive, readonly } from "vue"
import IUser from "../assets/constants/user"
import { definedOrDefault } from './useObjectUtil'

const getState = () => JSON.parse(localStorage.getItem('state') ?? '{}')
const defaultValue = (key: string, value: any) => definedOrDefault(getState()[key], value)

export interface IState {
    user: IUser | undefined,
    apiUrl: 'https://localhost:44343',
    authHeader: Headers | undefined
}
const state = reactive<IState>({
    user: defaultValue('user', undefined),
    apiUrl: defaultValue('apiUrl', ''),
    authHeader: defaultValue('authHeader', undefined)
})

export function useState() {
    return {
        state: readonly(state)
    }
}