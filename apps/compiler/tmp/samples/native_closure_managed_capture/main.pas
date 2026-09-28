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
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: TFun0;
begin
  v0 := 'abc';
  v1 := ClosureCreate0(v0);
  Result := v1.Invoke(39);
end;
begin
  Halt(SpiralMain);
end.
