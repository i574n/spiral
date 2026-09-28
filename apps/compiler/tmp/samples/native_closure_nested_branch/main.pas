program SpiralGenerated;
{$mode objfpc}{$H+}

type
  ClosureValue0 = record
    v0: AnsiString;
    v1: LongInt;
    variant: LongInt;
  end;

function ClosureValueCreate0(v0: AnsiString; v1: LongInt; variant: LongInt): ClosureValue0;
begin
  Result.v0 := v0;
  Result.v1 := v1;
  Result.variant := variant;
end;

function ClosureInvoke0(x: ClosureValue0; v2: LongInt): LongInt;
var
  v0: AnsiString;
  v1: LongInt;
  closure0_v3: LongInt;
  closure1_v3: LongInt;
begin
  if (x.variant = 0) then begin
    v0 := x.v0;
    v1 := x.v1;
    if (v2 > 0) then begin
      closure0_v3 := ((Length(v0) + v1) + v2);
    end else begin
      closure0_v3 := 0;
    end;
    Exit(closure0_v3);
  end else begin
    v0 := x.v0;
    v1 := x.v1;
    if (v2 > 0) then begin
      closure1_v3 := (((Length(v0) + v1) + v2) - 1);
    end else begin
      closure1_v3 := (-1);
    end;
    Exit(closure1_v3);
  end;
end;

function method0(v0: ClosureValue0): LongInt;
begin
  Exit(ClosureInvoke0(v0, 37));
end;

function SpiralMain: LongInt;
var
  flag: Boolean;
  selected: ClosureValue0;
  name: AnsiString;
begin
  flag := True;
  if flag then begin
    name := 'abc';
    selected := ClosureValueCreate0(name, 2, 0);
  end else begin
    name := 'wxyz';
    selected := ClosureValueCreate0(name, 2, 1);
  end;
  Exit(method0(selected));
end;

begin
  Halt(SpiralMain);
end.
