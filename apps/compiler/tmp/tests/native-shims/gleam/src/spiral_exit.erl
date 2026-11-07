-module(spiral_exit).
-export([halt/1]).

halt(Result) when is_integer(Result), Result >= 0 -> erlang:halt(Result);
halt(Result) when is_integer(Result) -> erlang:halt(Result + 4294967296);
halt(_) -> erlang:halt(0).
