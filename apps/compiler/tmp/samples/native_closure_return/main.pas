program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun1 = class;
  TFun1 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  TFun0 = class
    function Invoke(a0: AnsiString): TFun1; virtual; abstract;
  end;
  TClosure0 = class(TFun0)  function Invoke(v0: AnsiString): TFun1; override; end;
  TClosure1 = class(TFun1) v0: AnsiString; function Invoke(v1: LongInt): LongInt; override; end;
function ClosureCreate1(v0: AnsiString): TFun1; forward;
function ClosureCreate0: TFun0; forward;
function method0(v0: TFun1): LongInt; forward;
function TClosure1.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
begin
  v2 := LongInt(Length(v0));
  v3 := v2 + v1;
  Result := v3;
end;
function ClosureCreate1(v0: AnsiString): TFun1;
var c: TClosure1;
begin
  c := TClosure1.Create; c.v0 := v0;
  Result := c;
end;
function TClosure0.Invoke(v0: AnsiString): TFun1;
begin
  Result := ClosureCreate1(v0);
end;
function ClosureCreate0: TFun0;
var c: TClosure0;
begin
  c := TClosure0.Create; 
  Result := c;
end;
function method0(v0: TFun1): LongInt;
begin
  Result := v0.Invoke(39);
end;
function SpiralMain: LongInt;
var
  v0: TFun0;
  v1: AnsiString;
  v2: TFun1;
begin
  v0 := ClosureCreate0;
  v1 := 'abc';
  v2 := v0.Invoke(v1);
  Result := method0(v2);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
