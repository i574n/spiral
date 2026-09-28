program SpiralFailureLifecycle;
{$mode objfpc}{$H+}

uses SysUtils, SpiralTypesRecord, SpiralFailureRaise, SpiralConsumerUse;

var
  value: Array0;
  pairValue: Tuple0;
  ignored: LongInt;
  raised: Boolean;

begin
  value := ArrayCreate0(1, False);
  DynamicArraySet0(value, 0, 7);
  DynamicArrayClone0(value);
  pairValue := TupleCreate0(value, 41);
  if DynamicArrayRefCount0(value) <> 2 then Halt(91);

  raised := False;
  try
    ignored := method0(pairValue);
    if ignored = 0 then begin end;
  except
    on E: Exception do
    begin
      if E.Message <> 'package-owned managed array failure' then Halt(92);
      raised := True;
    end;
  end;

  if not raised then Halt(93);
  if DynamicArrayRefCount0(value) <> 1 then Halt(94);
  if DynamicArrayGet0(value, 0) <> 7 then Halt(95);
  DynamicArrayDrop0(value);
  if value <> nil then Halt(96);
  Halt(42);
end.
