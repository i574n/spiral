program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TFun0 = class;
  TFun0 = class(TSpiralRc)
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  Ta_c0 = class(TFun0)  function Invoke(v0: LongInt): LongInt; override; end;
  Tb_c1 = class(TFun0)  function Invoke(v0: LongInt): LongInt; override; end;
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
function ClosureCreate0: TFun0; forward;
function ClosureCreate1: TFun0; forward;
function method0(v0: TFun0): LongInt; forward;
function Ta_c0.Invoke(v0: LongInt): LongInt;
var
  v1: LongInt;
begin
  v1 := v0 + 2;
  Result := v1;
end;
function ClosureCreate0: TFun0;
var c: Ta_c0;
begin
  c := Ta_c0.Create; 
  Result := c;
end;
function Tb_c1.Invoke(v0: LongInt): LongInt;
var
  v1: LongInt;
begin
  v1 := v0 + 3;
  Result := v1;
end;
function ClosureCreate1: TFun0;
var c: Tb_c1;
begin
  c := Tb_c1.Create; 
  Result := c;
end;
function method0(v0: TFun0): LongInt;
begin
  Result := v0.Invoke(40);
end;
function SpiralMain: LongInt;
var
  v0: Boolean;
  v3: TFun0;
begin
  v0 := True;
  if v0 then begin
      v3 := ClosureCreate0;
  end else begin
      v3 := ClosureCreate1;
  end;
  Result := method0(v3);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
