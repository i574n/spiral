program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c0_0: LongInt; c1_0: LongInt; end;
function method0(v0: TUS0): LongInt; forward;
function US0_0(a0: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_1(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function method0(v0: TUS0): LongInt;
var
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  case v0.tag of
      0: begin // Hit
          v1 := v0.c0_0;
          Result := v1;
      end;
      1: begin // Miss
          v2 := v0.c1_0;
          v3 := -v2;
          Result := v3;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: Boolean;
  v3: TUS0;
  v4: LongInt;
  v5: LongInt;
begin
  v0 := True;
  if v0 then begin
      v3 := US0_0(7);
  end else begin
      v3 := US0_1(3);
  end;
  v4 := method0(v3);
  v5 := v4 - 7;
  Result := v5;
end;
begin
  Halt(SpiralMain);
end.
