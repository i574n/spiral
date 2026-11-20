-module(main_ffi).
-export([array_new/2, array_get/2, array_set/3, ref_new/1, ref_get/1, ref_set/2]).

array_new(Size, Fill) ->
    Key = make_ref(),
    put(Key, array:new(Size, [{fixed, true}, {default, Fill}])),
    Key.

array_get(Key, I) -> array:get(I, get(Key)).

array_set(Key, I, Value) ->
    put(Key, array:set(I, Value, get(Key))),
    nil.

ref_new(Value) ->
    Key = make_ref(),
    put(Key, Value),
    Key.

ref_get(Key) -> get(Key).

ref_set(Key, Value) ->
    put(Key, Value),
    nil.
