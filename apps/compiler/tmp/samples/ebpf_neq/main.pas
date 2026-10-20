program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongWord;
  v3: LongWord;
  v4: Single;
  v5: Single;
  v6: Boolean;
  v7: Boolean;
  v8: Boolean;
begin
  v0 := 3;
  v1 := 4;
  v2 := 1;
  v3 := 1;
  v4 := 1.5;
  v5 := -v4;
  v6 := v0 <> v1;
  if v6 then begin
      v7 := v2 <> v3;
      if v7 then begin
          Result := 2;
      end else begin
          v8 := v5 = (-1.5);
          if v8 then begin
              Result := 0;
          end else begin
              Result := 3;
          end;
      end;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
