program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut0 = class;
  TMut0 = class l0: AnsiString; l1: AnsiString; end;
function MutCreate0(a0: AnsiString; a1: AnsiString): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0; Result.l1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: TMut0;
  v3: AnsiString;
  v4: AnsiString;
  v5: AnsiString;
  v6: AnsiString;
  v7: Boolean;
  v9: Boolean;
  v8: Boolean;
begin
  v0 := 'no';
  v1 := 'nay';
  v2 := MutCreate0(v0, v1);
  v3 := 'hi';
  v4 := 'yo';
  v2.l0 := v3;
  v2.l1 := v4;
  v5 := v2.l0;
  v6 := v2.l1;
  v7 := v5 = 'hi';
  if v7 then begin
      v8 := v6 = 'yo';
      v9 := v8;
  end else begin
      v9 := False;
  end;
  if v9 then begin
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
