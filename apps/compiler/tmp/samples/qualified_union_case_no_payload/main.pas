program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c0_0: LongInt; end;
function US0_Hit(a0: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_Hold: TUS0;
begin
  Result.tag := 1; 
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TUS0;
  v2: TUS0;
  v5: LongInt;
  v3: LongInt;
  v8: LongInt;
  v6: LongInt;
  v9: LongInt;
begin
  v0 := 3;
  v1 := US0_Hit(v0);
  v2 := US0_Hold;
  case v1.tag of
      0: begin
          v3 := v1.c0_0;
          v5 := v3;
      end;
      1: begin
          v5 := 40;
      end;
  end;
  case v2.tag of
      0: begin
          v6 := v2.c0_0;
          v8 := v6;
      end;
      1: begin
          v8 := 40;
      end;
  end;
  v9 := v5 + v8;
  Result := v9;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
