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
  v9: Boolean;
  v10: Boolean;
begin
  v0 := 3;
  v1 := 4;
  v2 := 1;
  v3 := 1;
  v4 := 1.5;
  v5 := -v4;
  v6 := v0 = v1;
  v7 := v6 <> True;
  if v7 then begin
      v8 := v2 = v3;
      v9 := v8 <> True;
      if v9 then begin
          Result := 2;
      end else begin
          v10 := v5 = (-1.5);
          if v10 then begin
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
