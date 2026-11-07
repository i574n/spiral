program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TFun0 = class;
  TFun1 = class;
  TFun1 = class(TSpiralRc)
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  TFun0 = class(TSpiralRc)
    function Invoke(a0: LongInt): TFun1; virtual; abstract;
  end;
  Tf_c0 = class(TFun0)  function Invoke(v0: LongInt): TFun1; override; end;
  Tclosure1 = class(TFun1) v0: LongInt; function Invoke(v1: LongInt): LongInt; override; end;
procedure TSpiralRc.DropFields;
begin
end;
procedure SpiralRetain(o: TSpiralRc);
begin
  if o <> nil then Inc(o.refc);
end;
procedure SpiralRelease(o: TSpiralRc);
begin
  if o <> nil then begin Dec(o.refc); if o.refc < 0 then begin o.DropFields; o.Free; end; end;
end;
function SpiralKeep(o: TSpiralRc): TSpiralRc;
begin
  SpiralRetain(o); Result := o;
end;
function ClosureCreate1(v0: LongInt): TFun1; forward;
function ClosureCreate0: TFun0; forward;
function Tclosure1.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
begin
  v2 := v0 * 10;
  v3 := v2 + v1;
  Result := v3;
  SpiralRelease(Self);
end;
function ClosureCreate1(v0: LongInt): TFun1;
var c: Tclosure1;
begin
  c := Tclosure1.Create; c.v0 := v0;
  Result := c;
end;
function Tf_c0.Invoke(v0: LongInt): TFun1;
begin
  Result := ClosureCreate1(v0);
  SpiralRelease(Self);
end;
function ClosureCreate0: TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; 
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: TFun0;
  v1: TFun1;
  v2: LongInt;
  v3: Boolean;
begin
  v0 := ClosureCreate0;
  SpiralRetain(v0);
  v1 := v0.Invoke(3);
  SpiralRetain(v1);
  SpiralRelease(v0);
  v2 := v1.Invoke(4);
  SpiralRelease(v1);
  v3 := v2 = 34;
  if v3 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
