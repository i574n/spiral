-module(main_ffi).
-export([array_new/2, array_get/2, array_set/3]).

array_new(Size, Fill) ->
    Key = make_ref(),
    put(Key, array:new(Size, [{fixed, true}, {default, Fill}])),
    Key.

array_get(Key, I) -> array:get(I, get(Key)).

array_set(Key, I, Value) ->
    put(Key, array:set(I, Value, get(Key))),
    nil.
