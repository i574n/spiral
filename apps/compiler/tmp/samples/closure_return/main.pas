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
    function Invoke(a0: LongInt): TFun1; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): TFun1; override; end;
  Tg_c1 = class(TFun1) v0: LongInt; v1: LongInt; function Invoke(v2: LongInt): LongInt; override; end;
function ClosureCreate1(v0: LongInt; v1: LongInt): TFun1; forward;
function ClosureCreate0(v0: LongInt): TFun0; forward;
function Tg_c1.Invoke(v2: LongInt): LongInt;
var
  v3: Boolean;
  v4: LongInt;
begin
  v3 := v1 = 0;
  if v3 then begin
      Result := 0;
  end else begin
      v4 := v2 + v0;
      Result := v4;
  end;
end;
function ClosureCreate1(v0: LongInt; v1: LongInt): TFun1;
var c: Tg_c1;
begin
  c := Tg_c1.Create; c.v0 := v0; c.v1 := v1;
  Result := c;
end;
function Tf_c0.Invoke(v1: LongInt): TFun1;
begin
  Result := ClosureCreate1(v0, v1);
end;
function ClosureCreate0(v0: LongInt): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TFun0;
  v2: TFun1;
  v3: LongInt;
  v4: Boolean;
begin
  v0 := 7;
  v1 := ClosureCreate0(v0);
  v2 := v1.Invoke(1);
  v3 := v2.Invoke(0);
  v4 := v3 = 7;
  if v4 then begin
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
