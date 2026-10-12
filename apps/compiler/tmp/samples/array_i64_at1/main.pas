program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of Int64;
function SpiralMain: LongInt;
var
  v0: TArray0;
  tmp1: TArray0;
  v1: Int64;
  v2: Int64;
  v3: Boolean;
begin
  tmp1 := nil;
  SetLength(tmp1, 2);
  v0 := tmp1;
  v1 := 5000000000;
  v0[1] := v1;
  v2 := v0[1];
  v3 := v2 = 5000000000;
  if v3 then begin
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
