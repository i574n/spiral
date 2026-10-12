program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method0(v0: ShortInt): ShortInt; forward;
function method0(v0: ShortInt): ShortInt;
var
  v1: Boolean;
begin
  v1 := v0 = 0;
  if v1 then begin
      Result := 1;
  end else begin
      Result := v0;
  end;
end;
function SpiralMain: LongInt;
var
  v0: ShortInt;
  v1: ShortInt;
  v2: Boolean;
begin
  v0 := 100;
  v1 := method0(v0);
  v2 := v1 = 100;
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
