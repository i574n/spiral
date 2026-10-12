program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongWord;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: LongWord;
  v3: LongWord;
  v4: LongWord;
  v5: LongInt;
  v6: Boolean;
  v8: Boolean;
  v7: Boolean;
begin
  v0 := 3;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v1[0] := 4000000000;
  v1[1] := 1;
  v2 := v1[0];
  v3 := v1[1];
  v4 := v2 + v3;
  v5 := LongInt(Length(v1));
  v6 := v5 = v0;
  if v6 then begin
      v7 := v4 = 4000000001;
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
