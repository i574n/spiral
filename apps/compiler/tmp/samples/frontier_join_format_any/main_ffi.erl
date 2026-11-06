-module(main_ffi).
-export([ref_new/1, ref_get/1, ref_set/2]).

ref_new(Value) ->
    Key = make_ref(),
    put(Key, Value),
    Key.

ref_get(Key) -> get(Key).

ref_set(Key, Value) ->
    put(Key, Value),
    nil.
