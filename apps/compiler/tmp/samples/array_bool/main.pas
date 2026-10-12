program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of Boolean;
function SpiralMain: LongInt;
var
  v0: TArray0;
  tmp1: TArray0;
  v1: Boolean;
  v2: Boolean;
begin
  tmp1 := nil;
  SetLength(tmp1, 1);
  v0 := tmp1;
  v1 := True;
  v0[0] := v1;
  v2 := v0[0];
  if v2 then begin
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
