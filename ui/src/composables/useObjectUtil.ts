import { cloneDeep, isEmpty, isEqual } from 'lodash-es'

/** If value is defined and not null, returns value; else returns default value */
const definedOrDefault = <T>(value: T, defaultValue: NonNullable<T>) => {
	const v = value as NonNullable<T>
	return v != null ? v : defaultValue
}

export function useObjectUtils() {
	return {
		definedOrDefault,
		copy: cloneDeep,
		isEmpty,
		isEqual
	}
}
