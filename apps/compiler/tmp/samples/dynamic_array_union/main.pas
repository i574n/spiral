program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
  TUS0 = record tag: LongInt; c1_0: TArray0; end;
function score_0(v0: TUS0): LongInt; forward;
function US0_Empty: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Values(a0: TArray0): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function score_0(v0: TUS0): LongInt;
var
  v1: TArray0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  case v0.tag of
      0: begin
          Result := 0;
      end;
      1: begin
          v1 := v0.c1_0;
          v2 := LongInt(Length(v1));
          v3 := v1[0];
          v4 := v2 + v3;
          v5 := v1[1];
          v6 := v4 + v5;
          Result := v6;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: TUS0;
  v3: LongInt;
  v4: LongInt;
begin
  v0 := 2;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v1[0] := 4;
  v1[1] := 5;
  v2 := US0_Values(v1);
  v3 := score_0(v2);
  v4 := v3 - 11;
  Result := v4;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
