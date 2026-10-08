program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TTuple0 = record f0: AnsiString; f1: LongInt; end;
function method0(v0: AnsiString): TTuple0; forward;
function method1(v0: LongInt; v1: AnsiString): LongInt; forward;
function TupleCreate0(f0: AnsiString; f1: LongInt): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function method0(v0: AnsiString): TTuple0;
var
  v1: LongInt;
begin
  v1 := LongInt(Length(v0));
  Result := TupleCreate0(v0, v1);
end;
function method1(v0: LongInt; v1: AnsiString): LongInt;
var
  v2: LongInt;
  v3: LongInt;
begin
  v2 := LongInt(Length(v1));
  v3 := v2 + v0;
  Result := v3;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: LongInt;
  tmp3: TTuple0;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := 'qwe';
  tmp3 := method0(v0);
  v1 := tmp3.f0;
  v2 := tmp3.f1;
  v3 := method1(v2, v1);
  v4 := method1(v2, v1);
  v5 := v3 + v4;
  v6 := v5 - 12;
  Result := v6;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
