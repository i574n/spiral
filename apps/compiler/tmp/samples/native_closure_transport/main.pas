program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun0 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  TClosure0 = class(TFun0) v0: AnsiString; function Invoke(v1: LongInt): LongInt; override; end;
function ClosureCreate0(v0: AnsiString): TFun0; forward;
function method0(v0: TFun0; v1: LongInt): LongInt; forward;
function TClosure0.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
begin
  v2 := LongInt(Length(v0));
  v3 := v2 + v1;
  Result := v3;
end;
function ClosureCreate0(v0: AnsiString): TFun0;
var c: TClosure0;
begin
  c := TClosure0.Create; c.v0 := v0;
  Result := c;
end;
function method0(v0: TFun0; v1: LongInt): LongInt;
begin
  Result := v0.Invoke(v1);
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: TFun0;
  v2: LongInt;
begin
  v0 := 'abc';
  v1 := ClosureCreate0(v0);
  v2 := 39;
  Result := method0(v1, v2);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
