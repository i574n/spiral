program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TFun0 = class;
  TUS0 = record tag: LongInt; c1_0: LongInt; end;
  TFun0 = class(TSpiralRc)
    function Invoke(a0: LongInt): TUS0; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): TUS0; override; end;
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
function ClosureCreate0(v0: LongInt): TFun0; forward;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Some(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function Tf_c0.Invoke(v1: LongInt): TUS0;
var
  v2: Boolean;
begin
  v2 := v1 = 0;
  if v2 then begin
      Result := US0_None;
  end else begin
      Result := US0_Some(v0);
  end;
  SpiralRelease(Self);
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
  v2: TUS0;
  v3: LongInt;
  v4: Boolean;
begin
  v0 := 7;
  v1 := ClosureCreate0(v0);
  SpiralRetain(v1);
  v2 := v1.Invoke(1);
  SpiralRelease(v1);
  case v2.tag of
      0: begin
          Result := 1;
      end;
      1: begin
          v3 := v2.c1_0;
          v4 := v3 = 7;
          if v4 then begin
              Result := 0;
          end else begin
              Result := 1;
          end;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
