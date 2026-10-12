program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut0 = class;
  TMut0 = class l0: Single; l1: AnsiString; end;
function MutCreate0(a0: Single; a1: AnsiString): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0; Result.l1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: Single;
  v1: AnsiString;
  v2: TMut0;
  v3: Single;
  v4: AnsiString;
  v5: Single;
  v6: AnsiString;
  v7: Boolean;
  v9: Boolean;
  v8: Boolean;
begin
  v0 := 1.5;
  v1 := 'no';
  v2 := MutCreate0(v0, v1);
  v3 := 2.5;
  v4 := 'hi';
  v2.l0 := v3;
  v2.l1 := v4;
  v5 := v2.l0;
  v6 := v2.l1;
  v7 := v5 = 2.5;
  if v7 then begin
      v8 := v6 = 'hi';
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
