program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method0(v0: LongInt): AnsiString; forward;
function method0(v0: LongInt): AnsiString;
var
  v1: Boolean;
  v2: AnsiString;
  v3: AnsiString;
begin
  v1 := v0 = 0;
  if v1 then begin
      v2 := 'no';
      Result := v2;
  end else begin
      v3 := 'hi';
      Result := v3;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: Boolean;
begin
  v0 := 7;
  v1 := method0(v0);
  v2 := v1 = 'hi';
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
