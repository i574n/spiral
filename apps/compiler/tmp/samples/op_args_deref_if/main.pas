program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut0 = class;
  TMut0 = class l0: AnsiString; end;
function MutCreate0(a0: AnsiString): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: TMut0;
  v2: LongInt;
  v3: AnsiString;
  v4: AnsiString;
  v5: Boolean;
  v7: LongInt;
  v6: LongInt;
  v8: LongInt;
  v9: Boolean;
  v10: LongInt;
  v11: Boolean;
begin
  v0 := 'deref';
  v1 := MutCreate0(v0);
  v2 := 3;
  v3 := 'deref!';
  v1.l0 := v3;
  v4 := v1.l0;
  v5 := v2 = 3;
  if v5 then begin
      v6 := v2 + 1;
      v7 := v6;
  end else begin
      v7 := 0;
  end;
  Write(v4, ' ', v7, #10);
  v8 := v2 * 2;
  v9 := v2 > 0;
  if v9 then begin
      v10 := 6;
  end else begin
      v10 := 0;
  end;
  v11 := v8 = v10;
  if v11 then begin
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
