program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun0 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  TClosure0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): LongInt; override; end;
  TClosure1 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): LongInt; override; end;
function ClosureCreate0(v0: LongInt): TFun0; forward;
function ClosureCreate1(v0: LongInt): TFun0; forward;
function method0(v0: TFun0): LongInt; forward;
function TClosure0.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
begin
  v2 := v1 + v0;
  Result := v2;
end;
function ClosureCreate0(v0: LongInt): TFun0;
var c: TClosure0;
begin
  c := TClosure0.Create; c.v0 := v0;
  Result := c;
end;
function TClosure1.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
begin
  v2 := v1 + v0;
  Result := v2;
end;
function ClosureCreate1(v0: LongInt): TFun0;
var c: TClosure1;
begin
  c := TClosure1.Create; c.v0 := v0;
  Result := c;
end;
function method0(v0: TFun0): LongInt;
begin
  Result := v0.Invoke(40);
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: Boolean;
  v5: TFun0;
begin
  v0 := 2;
  v1 := 3;
  v2 := True;
  if v2 then begin
      v5 := ClosureCreate0(v0);
  end else begin
      v5 := ClosureCreate1(v1);
  end;
  Result := method0(v5);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
