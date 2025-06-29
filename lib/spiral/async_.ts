import { Async, singleton } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/AsyncBuilder.js";
import { defaultOf } from "../../deps/polyglot/deps/Fable/src/fable-library-ts/Util.js";

export function method1(v0_1: any): Async<any> {
    return singleton.Delay<any>((): Async<any> => {
        const v612: any = defaultOf();
        return singleton.Return<any>(v612);
    });
}

export function method0(v0_1: any): Async<any> {
    return method1(v0_1);
}

export function closure0(unitVar: void, v0_1: any): Async<any> {
    return method0(v0_1);
}

export const v0 = (v: any): Async<any> => closure0(undefined, v);

export function merge_cancellation_token_with_default_async(x: any): Async<any> {
    return v0(x);
}


