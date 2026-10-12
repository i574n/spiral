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
  v5: LongWord;
  v6: Boolean;
  v8: Boolean;
  v7: Boolean;
begin
  v0 := 65536;
  v1 := 65536;
  v2 := 4294967295;
  v3 := 3;
  v4 := v0 * v1;
  v5 := v2 * v3;
  v6 := v4 = 0;
  if v6 then begin
      v7 := v5 = 4294967293;
      v8 := v7;
  end else begin
      v8 := False;
  end;
  if v8 then begin
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
