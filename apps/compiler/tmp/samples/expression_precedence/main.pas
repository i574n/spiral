program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method0(v0: LongInt; v1: LongInt): Boolean; forward;
function method0(v0: LongInt; v1: LongInt): Boolean;
var
  v2: LongInt;
  v3: Boolean;
  v4: LongInt;
  v5: LongInt;
  v6: Boolean;
  v7: Boolean;
begin
  v2 := -v0 ;
  v3 := v2 <= 0;
  if v3 then begin
      v4 := v1 * 2;
      v5 := v0 + v4;
      v6 := v5 >= 9;
      if v6 then begin
          Result := True;
      end else begin
          v7 := v1 = 0;
          Result := v7;
      end;
  end else begin
      Result := False;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: Boolean;
begin
  v0 := 3;
  v1 := 3;
  v2 := method0(v0, v1);
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
