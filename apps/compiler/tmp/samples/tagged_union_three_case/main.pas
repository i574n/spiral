program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c1_0: LongInt; c2_0: Boolean; end;
function method0(v0: TUS0): LongInt; forward;
function US0_0: TUS0;
begin
  Result.tag := 0; 
end;
function US0_1(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function US0_2(a0: Boolean): TUS0;
begin
  Result.tag := 2; Result.c2_0 := a0;
end;
function method0(v0: TUS0): LongInt;
var
  v2: Boolean;
  v1: LongInt;
begin
  case v0.tag of
      2: begin // Flag
          v2 := v0.c2_0;
          if v2 then begin
              Result := 11;
          end else begin
              Result := 5;
          end;
      end;
      1: begin // Hit
          v1 := v0.c1_0;
          Result := v1;
      end;
      0: begin // Idle
          Result := 3;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Boolean;
  v7: TUS0;
  v3: Boolean;
  v8: LongInt;
  v9: LongInt;
begin
  v0 := 2;
  v1 := v0 = 0;
  if v1 then begin
      v7 := US0_0;
  end else begin
      v3 := v0 = 1;
      if v3 then begin
          v7 := US0_1(7);
      end else begin
          v7 := US0_2(True);
      end;
  end;
  v8 := method0(v7);
  v9 := v8 - 11;
  Result := v9;
end;
begin
  Halt(SpiralMain);
end.
