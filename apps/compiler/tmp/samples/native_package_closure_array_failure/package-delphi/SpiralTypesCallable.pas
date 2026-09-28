unit SpiralTypesCallable;
{$mode objfpc}{$H+}

interface

uses SysUtils;

type
  Array0 = array of LongInt;
  ClosureValue0 = record
    v0: Array0;
    variant: LongInt;
  end;

function ArrayCreate0(len: LongInt; init_at_zero: Boolean): Array0;
procedure DynamicArraySet0(var data: Array0; index: LongInt; value: LongInt);
function DynamicArrayGet0(const data: Array0; index: LongInt): LongInt;
function DynamicArrayLen0(const data: Array0): LongInt;
procedure DynamicArrayClone0(const data: Array0);
procedure DynamicArrayDrop0(var data: Array0);
function ClosureValueCreate0(v0: Array0; variant: LongInt): ClosureValue0;
function ClosureInvoke0(x: ClosureValue0; v1: LongInt): LongInt;

implementation

function ArrayCreate0(len: LongInt; init_at_zero: Boolean): Array0;
begin
  if len < 0 then raise ERangeError.Create('negative Spiral array length');
  SetLength(Result, len);
  if not init_at_zero then begin end;
end;
procedure DynamicArraySet0(var data: Array0; index: LongInt; value: LongInt);
begin
  if (index < 0) or (index >= Length(data)) then raise ERangeError.Create('Spiral array index out of bounds');
  data[index] := value;
end;
function DynamicArrayGet0(const data: Array0; index: LongInt): LongInt;
begin
  if (index < 0) or (index >= Length(data)) then raise ERangeError.Create('Spiral array index out of bounds');
  Result := data[index];
end;
function DynamicArrayLen0(const data: Array0): LongInt;
begin
  Result := Length(data);
end;
procedure DynamicArrayClone0(const data: Array0);
begin
end;
procedure DynamicArrayDrop0(var data: Array0);
begin
  SetLength(data, 0);
end;

function ClosureValueCreate0(v0: Array0; variant: LongInt): ClosureValue0;
begin
  Result.v0 := v0;
  Result.variant := variant;
end;

function ClosureInvoke0(x: ClosureValue0; v1: LongInt): LongInt;
var
  observed: LongInt;
begin
  if (x.variant = 0) then begin
    observed := DynamicArrayGet0(x.v0, 0);
    if (observed < 0) then begin
      raise Exception.Create('package-owned managed array closure negative capture');
    end;
    if (v1 = 0) then begin
      raise Exception.Create('package-owned managed array closure zero argument');
    end;
    raise Exception.Create('package-owned managed array closure failure');
  end else begin
    observed := DynamicArrayGet0(x.v0, 0);
    if (observed < 0) then begin
      raise Exception.Create('package-owned managed array closure negative capture');
    end;
    if (v1 = 0) then begin
      raise Exception.Create('package-owned managed array closure alternate zero argument');
    end;
    raise Exception.Create('package-owned managed array closure failure');
  end;
end;

end.
