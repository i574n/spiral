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
    function Invoke(a0: LongInt): AnsiString; virtual; abstract;
  end;
  TFun0 = class(TSpiralRc)
    function Invoke(a0: LongInt): TFun1; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: AnsiString; function Invoke(v1: LongInt): TFun1; override; end;
  Tg_c1 = class(TFun1) v0: AnsiString; v1: LongInt; function Invoke(v2: LongInt): AnsiString; override; end;
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
function ClosureCreate1(v0: AnsiString; v1: LongInt): TFun1; forward;
function ClosureCreate0(v0: AnsiString): TFun0; forward;
function Tg_c1.Invoke(v2: LongInt): AnsiString;
var
  v3: Boolean;
  v4: AnsiString;
begin
  v3 := v1 = 0;
  if v3 then begin
      v4 := 'no';
      Result := v4;
  end else begin
      Result := v0;
  end;
end;
function ClosureCreate1(v0: AnsiString; v1: LongInt): TFun1;
var c: Tg_c1;
begin
  c := Tg_c1.Create; c.v0 := v0; c.v1 := v1;
  Result := c;
end;
function Tf_c0.Invoke(v1: LongInt): TFun1;
begin
  Result := ClosureCreate1(v0, v1);
end;
function ClosureCreate0(v0: AnsiString): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: TFun0;
  v2: TFun1;
  v3: AnsiString;
  v4: Boolean;
begin
  v0 := 'hi';
  v1 := ClosureCreate0(v0);
  v2 := v1.Invoke(1);
  v3 := v2.Invoke(0);
  v4 := v3 = 'hi';
  if v4 then begin
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
