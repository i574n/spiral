program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c0_0: LongInt; c1_0: LongInt; c1_1: LongInt; end;
function sum_0(v0: TUS0): LongInt; forward;
function US0_One(a0: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_Both(a0: LongInt; a1: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function sum_0(v0: TUS0): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v1: LongInt;
begin
  case v0.tag of
      1: begin
          v2 := v0.c1_0;
          v3 := v0.c1_1;
          v4 := v2 * 10;
          v5 := v4 + v3;
          Result := v5;
      end;
      0: begin
          v1 := v0.c0_0;
          Result := v1;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: Boolean;
  v3: TUS0;
  v6: TUS0;
  v7: LongInt;
  v8: Boolean;
  v11: Boolean;
  v9: LongInt;
  v10: Boolean;
begin
  v0 := True;
  if v0 then begin
      v3 := US0_Both(3, 4);
  end else begin
      v3 := US0_One(1);
  end;
  if v0 then begin
      v6 := US0_One(5);
  end else begin
      v6 := US0_Both(1, 1);
  end;
  v7 := sum_0(v3);
  v8 := v7 = 34;
  if v8 then begin
      v9 := sum_0(v6);
      v10 := v9 = 5;
      v11 := v10;
  end else begin
      v11 := False;
  end;
  if v11 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
