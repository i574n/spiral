program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function is_odd_1(v0: LongInt): Boolean; forward;
function is_even_0(v0: LongInt): Boolean; forward;
function is_odd_1(v0: LongInt): Boolean;
var
  v1: Boolean;
  v2: LongInt;
begin
  v1 := v0 = 0;
  if v1 then begin
      Result := False;
  end else begin
      v2 := v0 - 1;
      Result := is_even_0(v2);
  end;
end;
function is_even_0(v0: LongInt): Boolean;
var
  v1: Boolean;
  v2: LongInt;
begin
  v1 := v0 = 0;
  if v1 then begin
      Result := True;
  end else begin
      v2 := v0 - 1;
      Result := is_odd_1(v2);
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Boolean;
begin
  v0 := 10;
  v1 := is_even_0(v0);
  if v1 then begin
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
