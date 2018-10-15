// https://github.com/Steve-Fenton/TypeScriptUtilities
export class Guid {
    static newGuid() {
      return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        // To prevent typos (| instead of ||) no-bitwise rule of tslint is active. In this case however
        // it is a correct use of bitwise operator. So we disable the rule temporarily.
        /* tslint:disable:no-bitwise */
        const r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
        /* tslint:enable:no-bitwise */
        return v.toString(16);
        });
    }
}
