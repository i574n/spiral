program SpiralGenerated;
{$mode objfpc}{$H+}

type
  TSpiralManagedClosure = record
    captured: UnicodeString;
    bias: LongInt;
  end;

function SpiralManagedClosureInvoke(const closure: TSpiralManagedClosure; value: LongInt): LongInt;
begin
  Result := Length(closure.captured) + value + closure.bias;
end;

function SpiralMain: LongInt;
var
  flag: Boolean;
  leftValue, rightValue, selected: TSpiralManagedClosure;
begin
  flag := True;
  leftValue.captured := 'abc';
  leftValue.bias := 0;
  rightValue.captured := 'wxyz';
  rightValue.bias := -1;
  if flag then selected := leftValue else selected := rightValue;
  Result := SpiralManagedClosureInvoke(selected, 39);
end;

begin
  Halt(SpiralMain);
end.
