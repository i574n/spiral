program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TUS0 = record tag: LongInt; c1_0: AnsiString; end;
  TFun0 = class
    function Invoke(a0: LongInt): TUS0; virtual; abstract;
  end;
  Tclosure0 = class(TFun0)  function Invoke(v0: LongInt): TUS0; override; end;
function ClosureCreate0: TFun0; forward;
function method0(v0: TFun0): TUS0; forward;
function US0_Idle: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Text(a0: AnsiString): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function Tclosure0.Invoke(v0: LongInt): TUS0;
var
  v1: AnsiString;
begin
  v1 := 'managed';
  Result := US0_Text(v1);
end;
function ClosureCreate0: TFun0;
var c: Tclosure0;
begin
  c := Tclosure0.Create; 
  Result := c;
end;
function method0(v0: TFun0): TUS0;
begin
  Result := v0.Invoke(2);
end;
function SpiralMain: LongInt;
var
  v0: TFun0;
  v1: TUS0;
  v4: LongInt;
  v2: AnsiString;
  v5: LongInt;
begin
  v0 := ClosureCreate0;
  v1 := method0(v0);
  case v1.tag of
      0: begin
          v4 := 3;
      end;
      1: begin
          v2 := v1.c1_0;
          v4 := 11;
      end;
  end;
  v5 := v4 + 31;
  Result := v5;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
