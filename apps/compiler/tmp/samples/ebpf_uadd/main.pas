program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: LongWord;
  v1: LongWord;
  v2: LongWord;
  v3: LongWord;
  v4: LongWord;
  v5: Boolean;
  v7: Boolean;
  v6: Boolean;
begin
  v0 := 2147483647;
  v1 := 2;
  v2 := 1;
  v3 := v0 + v1;
  v4 := v0 + v2;
  v5 := v3 = 2147483649;
  if v5 then begin
      v6 := v4 = 2147483648;
      v7 := v6;
  end else begin
      v7 := False;
  end;
  if v7 then begin
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
