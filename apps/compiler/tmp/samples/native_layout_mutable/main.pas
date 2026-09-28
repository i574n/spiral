program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Mut0 = class
    RefCount: LongInt;
    v0: LongInt;
    v1: LongInt;
  end;

function MutCreate0(v0: LongInt; v1: LongInt): Mut0;
begin
  Result := Mut0.Create;
  Result.RefCount := 1;
  Result.v0 := v0;
  Result.v1 := v1;
end;
procedure MutAssign0(value: Mut0; v0: LongInt; v1: LongInt);
begin
  value.v0 := v0;
  value.v1 := v1;
end;
function MutGet0_0(value: Mut0): LongInt;
begin
  Result := value.v0;
end;
function MutGet0_1(value: Mut0): LongInt;
begin
  Result := value.v1;
end;
procedure MutDecref0(var value: Mut0);
begin
  if value = nil then Exit;
  Dec(value.RefCount);
  if value.RefCount = 0 then value.Free;
  value := nil;
end;

function SpiralMain: LongInt;
var
  v0: Mut0;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  v0 := MutCreate0(1, 2);
  MutAssign0(v0, 3, 4);
  v1 := MutGet0_0(v0);
  v2 := MutGet0_1(v0);
  MutDecref0(v0);
  v3 := (v1 + v2);
  Exit(v3);
end;

begin
  Halt(SpiralMain);
end.
